using System;
using System.IO;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Storage;

namespace ThraeX.Storage
{
    public class XnaStorageService : IStorageService
    {
        public XnaStorageService(String containerName)
        {
            Enabled = true;
            ContainerName = containerName;
            RequestStatus = StorageRequestState.NO_REQUEST;
        }

        public bool Enabled
        {
            get; private set;
        }

        private String ContainerName
        {
            get; set;
        }

        private bool GuideVisible
        {
        #if XBOX
            get { return Guide.IsVisible; }
        #else
            get { return false; }
        #endif
        }

        public StorageRequestState RequestStatus
        {
            get; private set;
        }

        public StorageDevice TitleStorage
        {
            get; private set;
        }

        public bool TitleStorageSelected
        {
            get { return TitleStorage != null; }
        }

        public bool TitleStorageConnected
        {
            get { return TitleStorageSelected && TitleStorage.IsConnected; }
        }

        public void MountTitleStorage()
        {
            if (TitleStorage != null) UnmountTitleStorage();

            if (!TitleStorageSelected && !GuideVisible && (RequestStatus == StorageRequestState.NO_REQUEST || RequestStatus == StorageRequestState.REQUEST_COMPLETE))
                StartTitleStorageDeviceRequest();
        }

        public void UnmountTitleStorage()
        {
            if (StorageContainerForTitleStorageIsActive)
                StorageContainerForTitleStorage.Dispose();

            TitleStorage = null;
        }

        private StorageContainer StorageContainerForTitleStorage
        {
            get; set;
        }

        private bool StorageContainerForTitleStorageIsActive
        {
            get { return (StorageContainerForTitleStorage != null && !StorageContainerForTitleStorage.IsDisposed); }
        }

        public StorageContainer OpenStorageContainerForTitleStorage()
        {
            if (!TitleStorageConnected)
                throw new InvalidOperationException("Cannot Open a StorageContainer unless a StorageDevice has been mounted");

            if (StorageContainerForTitleStorageIsActive)
                throw new InvalidOperationException("Cannot Open a new StorageContainer if a StorageContainer is already open");

            StorageContainerForTitleStorage = TitleStorage.OpenContainer(ContainerName);
            return StorageContainerForTitleStorage;
        }

        #region Private Actions
        private void StartTitleStorageDeviceRequest()
        {
            RequestStatus = StorageRequestState.WAITING_FOR_STORAGE_DEVICE_SELECTION;
            TitleStorage = null;
            Guide.BeginShowStorageDeviceSelector(new AsyncCallback(HandleTitleStorageDeviceSelection), this);
        }

        private void HandleTitleStorageDeviceSelection(IAsyncResult result)
        {
            TitleStorage = Guide.EndShowStorageDeviceSelector(result);

            if (!TitleStorageConnected)
            {
                RequestStatus = StorageRequestState.REQUEST_CANCELLED;
                Enabled = false;
            }
            else
                RequestStatus = StorageRequestState.REQUEST_COMPLETE;
        }
        #endregion
    }
}
