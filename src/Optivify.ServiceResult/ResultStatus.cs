﻿namespace Optivify.ServiceResult
{
    public enum ResultStatus
    {
        Success,            // Ok - HttpStatusCode 200
        Error,              // UnprocessableEntity - HttpStatusCode 422
        Invalid,            // BadRequest - HttpStatusCode 400
        Unauthorized,       // Unauthorized - HttpStatusCode 401
        Forbidden,          // Forbidden - HttpStatusCode 403
        NotFound,           // NotFound - HttpStatusCode 404
    }
}
