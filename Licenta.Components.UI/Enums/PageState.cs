namespace Licenta.Components.UI.Enums
{
    public enum PageState
    {
        // acces restrictionat asupra unei resurse
        AccesDenied,
        // Se face un apel extern si se asteapta raspunsul
        Loading,
        // s-a luat raspunsul
        Loaded,
        // eroare intalnita
        Error,
        // componenta in prima faza, inainte de orice interactiune
        Initial,
        // componenta dupa ce si-a indeplinit scopul
        Success,
    }
}
