using System;
using System.IO;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;

namespace ThraeX.Storage
{
    public class XnaStorageService : IStorageService
    {
        // When running on the Xbox, this flag is set to the value of the Guide.IsVisible property.
        // On the PC, we are not going to use the Guide, so this will simulate it always being set.
        // ReSharper disable ConvertToConstant
        private bool guideIsVisible = true;
        // ReSharper restore ConvertToConstant
        
        private readonly String title;
        private StorageDevice storageDevice;
        private StorageContainer storageContainer;
        private StorageRequestState storageRequestState;

        public XnaStorageService(String title)
        {
            this.title = title;
            storageRequestState = StorageRequestState.NO_REQUEST;
        }

        #region IStorageService Members
        public StorageRequestState RequestStatus
        {
            get { return storageRequestState; }
        }

        public bool StorageAvailable
        {
            get { return (storageDevice != null && storageDevice.IsConnected); }
        }

        public void SubmitStorageRequest()
        {
            #if XBOX
            guideIsVisible = Guide.IsVisible;
            #endif

            if (storageRequestState == StorageRequestState.NO_REQUEST && storageDevice == null && !guideIsVisible)
                StartStorageRequestAction();
            else if (storageRequestState == StorageRequestState.WAITING_FOR_STORAGE_DEVICE_SELECTION)
                throw new InvalidOperationException("Cannot Submit a Storage Device request when we have a request pending.");
        }

        public void ResetStorageRequest()
        {
            storageRequestState = StorageRequestState.NO_REQUEST;
        }

        public FileStream GetFileStreamForStorageOperation(string filename, FileMode fileMode)
        {
            storageContainer = storageDevice.OpenContainer(title);
            String filePath = Path.Combine(storageContainer.Path, filename);
            return new FileStream(filePath, fileMode);
        }

        public void EndStorageOperation()
        {
            if (storageContainer == null)
                throw new InvalidOperationException("Unable to close a null storageContainer");

            if (!storageContainer.IsDisposed)
            {
                storageContainer.Dispose();
                storageContainer = null;
            }
        }

        public bool IsFilePresentInStorage(String filename)
        {
            if (!StorageAvailable)
                throw new InvalidOperationException("Cannot check for presence of a file when no StorageDevice has been selected");

            if (storageContainer == null)
                storageContainer = storageDevice.OpenContainer(title);

            String filePath = Path.Combine(storageContainer.Path, filename);
            bool result =  File.Exists(filePath);

            EndStorageOperation();
            return result;
        }
        #endregion

        #region Private Actions
        private void StartStorageRequestAction()
        {
            storageRequestState = StorageRequestState.WAITING_FOR_STORAGE_DEVICE_SELECTION;
            storageDevice = null;
            storageContainer = null;
            Guide.BeginShowStorageDeviceSelector(new AsyncCallback(SelectDefaultUserStorageDevice), this);
        }

        private void SelectDefaultUserStorageDevice(IAsyncResult result)
        {
            storageDevice = Guide.EndShowStorageDeviceSelector(result);
            if (storageDevice == null || !storageDevice.IsConnected) storageRequestState = StorageRequestState.REQUEST_CANCELLED;
        }
        #endregion
    }
}
