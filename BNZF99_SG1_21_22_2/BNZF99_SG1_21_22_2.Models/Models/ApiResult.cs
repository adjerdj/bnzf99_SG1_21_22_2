using System.Collections.Generic;

namespace BNZF99_SG1_21_22_2.Models.Models
{
    public class ApiResult
    {
        public bool IsSuccessful { get; set; }

        public List<string> Messages { get; set; }

        public ApiResult()
        {
        }

        public ApiResult(bool isSuccessful, List<string> messages = null)
        {
            IsSuccessful = isSuccessful;
            Messages = messages;
        }
    }
}
