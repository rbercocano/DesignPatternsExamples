GUIFactory windowsFactory = new WindowsFactory();
Client windowsClient = new(windowsFactory);
windowsClient.RenderUI();

GUIFactory macOSFactory = new MacOSFactory();
Client macOSClient = new(macOSFactory);
macOSClient.RenderUI();

Console.ReadKey();
interface Button
{
    void Render();
}
interface Checkbox
{
    void Render();
}

class WindowsButton : Button
{
    public void Render()
    {
        Console.WriteLine("Render a Windows-style button");
    }
}

class MacOSButton : Button
{
    public void Render()
    {
        Console.WriteLine("Render a macOS-style button");
    }
}

class WindowsCheckbox : Checkbox
{
    public void Render()
    {
        Console.WriteLine("Render a Windows-style checkbox");
    }
}

class MacOSCheckbox : Checkbox
{
    public void Render()
    {
        Console.WriteLine("Render a macOS-style checkbox");
    }
}

// Abstract Factory
interface GUIFactory
{
    Button CreateButton();
    Checkbox CreateCheckbox();
}

class WindowsFactory : GUIFactory
{
    public Button CreateButton()
    {
        return new WindowsButton();
    }

    public Checkbox CreateCheckbox()
    {
        return new WindowsCheckbox();
    }
}

class MacOSFactory : GUIFactory
{
    public Button CreateButton()
    {
        return new MacOSButton();
    }

    public Checkbox CreateCheckbox()
    {
        return new MacOSCheckbox();
    }
}

// Client
class Client
{
    private GUIFactory guiFactory;

    public Client(GUIFactory factory)
    {
        guiFactory = factory;
    }

    public void RenderUI()
    {
        Button button = guiFactory.CreateButton();
        Checkbox checkbox = guiFactory.CreateCheckbox();

        button.Render();
        checkbox.Render();
    }
}