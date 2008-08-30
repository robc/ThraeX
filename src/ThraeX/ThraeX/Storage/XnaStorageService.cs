using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;

namespace ThraeX.Storage
{
    public class XnaStorageService : IStorageService
    {
        private String title;
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
            get { return this.storageRequestState; }
        }

        public bool StorageAvailable
        {
            get { return (this.storageDevice != null && this.storageDevice.IsConnected); }
        }

        public void SubmitStorageRequest()
        {
            if (storageRequestState == StorageRequestState.NO_REQUEST && storageDevice == null && !Guide.IsVisible)
            {
                storageRequestState = StorageRequestState.WAITING_FOR_STORAGE_DEVICE_SELECTION;
                this.storageDevice = null;
                this.storageContainer = null;
                Guide.BeginShowStorageDeviceSelector(new AsyncCallback(SelectDefaultUserStorageDevice), this);
            }
            else if (storageRequestState == StorageRequestState.WAITING_FOR_STORAGE_DEVICE_SELECTION)
            {
                throw new InvalidOperationException("Cannot Submit a Storage Device request when we have a request pending.");
            }
        }

        public void ResetStorageRequest()
        {
            this.storageRequestState = StorageRequestState.NO_REQUEST;
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
        private void SelectDefaultUserStorageDevice(IAsyncResult result)
        {
            storageDevice = Guide.EndShowStorageDeviceSelector(result);
            if (storageDevice == null || !storageDevice.IsConnected) storageRequestState = StorageRequestState.REQUEST_CANCELLED;
        }
        #endregion
    }
}
