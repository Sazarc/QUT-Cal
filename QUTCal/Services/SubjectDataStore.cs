﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QUTCal.Services
{
    public interface SubjectDataStore<T>
    {
        Task<bool> AddSubjectAsync(T subject);
        Task<bool> UpdateSubjectAsync(T subject);
        Task<bool> DeleteSubjectAsync(string id);
        Task<T> GetSubjectAsync(string id);
        Task<IEnumerable<T>> GetSubjectsAsync(bool forceRefresh = false);
    }
}
