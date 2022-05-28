namespace Wow.SharedKernel;

public class BusinessRuleViolationException: Exception
{
    public BusinessRuleViolationException(string message): base(message)
    {
        
    }
}