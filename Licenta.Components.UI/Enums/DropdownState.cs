namespace Licenta.Components.UI.Enums
{
    public class DropdownState
    {
        // If true, a dropdown menu will be visible.
        public bool Visible { get; init; }


        // If true, dropdown would not react to button click.
        public bool Disabled { get; init; }

        public DropdownState()
        {
            Visible = false;
            Disabled = false;
        }

        //constructor with parameters
        public DropdownState(bool visible, bool disabled)
        {
            Visible = visible;
            Disabled = disabled;
        }

    }
}
