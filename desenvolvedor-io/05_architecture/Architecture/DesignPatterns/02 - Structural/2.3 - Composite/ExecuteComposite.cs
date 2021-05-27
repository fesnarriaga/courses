namespace DesignPatterns.Composite
{
    public class ExecuteComposite
    {
        public static void Execute()
        {
            var registrationValidations = new Message("Registration was not done!");

            var userFormErrors = new Message("Invalid name");
            var nameSize = new InputFormMessage("Name must have more than 2 characters");
            var nameEmpty = new InputFormMessage("Name can not be empty");
            userFormErrors.Add(nameSize);
            userFormErrors.Add(nameEmpty);

            registrationValidations.Add(userFormErrors);

            var userDomainError = new Message("Failed to register user");
            var userDocumentDomain = new DomainMessage("Document already used");
            var userEmailDomain = new DomainMessage("Email already used");
            userDomainError.Add(userDocumentDomain);
            userDomainError.Add(userEmailDomain);

            registrationValidations.Add(userDomainError);

            var messageLevel1 = new Message("Level 1");
            var messageLevel2 = new Message("Level 2");
            var messageLevel3 = new Message("Level 3");
            var messageLevel4 = new Message("Level 4");
            var messageLevel5 = new Message("Level 5");
            messageLevel4.Add(messageLevel5);
            messageLevel3.Add(messageLevel4);
            messageLevel2.Add(messageLevel3);
            messageLevel1.Add(messageLevel2);

            registrationValidations.Add(messageLevel1);

            registrationValidations.ShowMessages(1);
        }
    }
}
