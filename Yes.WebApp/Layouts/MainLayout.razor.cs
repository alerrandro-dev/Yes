namespace Yes.WebApp.Layouts;

public partial class MainLayout
{
    private bool _drawerIsOpened;
    
    private void ChangeDrawerOpeningState() => _drawerIsOpened = !_drawerIsOpened;
}