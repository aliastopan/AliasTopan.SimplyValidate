namespace AliasTopan.SimplyValidate
{
    public readonly struct AnnotationError
    {
        private readonly string _memberName;
        private readonly string _errorMessage;

        public string MemberName => _memberName;
        public string ErrorMessage => _errorMessage;

        public AnnotationError(string memberName, string errorMessage)
        {
            _memberName = memberName;
            _errorMessage = errorMessage;
        }
    }
}