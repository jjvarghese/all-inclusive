namespace All_Inclusive.screens.form;

public class FormMetadata
{
    public string Title { get; set; }
    
    public string Text { get; set; }

    public string Placeholder { get; set; }
    public string Description { get; set; }
    public Keyboard Keyboard { get; set; }
    
    public string ErrorText { get; set; }
    
    public bool IsErrorVisible { get; set; }
}