namespace ElectronicJournalCourseProject.Validation
{
    public interface IElectronicJournalValidatable<T>  where T : class
    {
        bool Validate(T value);
    }
}
