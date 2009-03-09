using System;
using System.IO;
using Microsoft.Xna.Framework.Storage;

namespace ThraeX.Storage
{
    public enum StorageRequestState
    {
        NO_REQUEST, WAITING_FOR_STORAGE_DEVICE_SELECTION, REQUEST_COMPLETE, REQUEST_CANCELLED
    }

    public interface IStorageService
    {
        bool Enabled { get; }                       // Do we wish to use the StorageService
        StorageRequestState RequestStatus { get; }

        #region Functions related to accessing the StorageDevice used for "Title" Storage
        StorageDevice TitleStorage { get; }
        void MountTitleStorage();
        void UnmountTitleStorage();
        bool TitleStorageSelected { get; }
        bool TitleStorageConnected { get; }
        StorageContainer OpenStorageContainerForTitleStorage();
        #endregion
    }
}
