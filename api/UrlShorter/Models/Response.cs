using System.Collections.Generic;
using UrlShortener.Enums;

namespace UrlShortener.Models
{
    public class Response<TData>
    {
        public TData Data { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Success;
        public bool IsSuccess { get => Status == DataStatus.Success; }
        private List<string> _errors { get; } = new List<string>();
        public List<string> Errors => _errors;

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}
