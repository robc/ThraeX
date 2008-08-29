using System;
using System.IO;

namespace ThraeX.Storage
{
    public enum StorageRequestState
    {
        NO_REQUEST, WAITING_FOR_STORAGE_DEVICE_SELECTION, REQUEST_COMPLETE, REQUEST_CANCELLED
    }

    public interface IStorageService
    {
        StorageRequestState RequestStatus { get; }
        bool StorageAvailable { get; }
        void SubmitStorageRequest();
        void ResetStorageRequest();

        FileStream GetFileStreamForStorageOperation(String filename, FileMode fileMode);
        void EndStorageOperation();
    }
}
