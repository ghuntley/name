namespace Name
{
    public enum ResponseCode
    {
        CommandSuccessful = 100,
        RequiredParameterMissing = 203,
        ParameterValueError = 204,
        InvalidCommandUrl = 211,
        AuthorizationError = 221,
        CommandFailed = 240,
        UnexpectedErrorOrException = 250,
        AuthenticationError = 251,
        InsuffiicentFunds = 260,
        UnableToAuthorizeFunds = 261
    }
}