const initializeNav = () => {
        var elems = document.querySelectorAll('.sidenav');
        var instances = M.Sidenav.init(elems, {});
}

const initializeCollapsible = () => {
    var elems = document.querySelectorAll('.collapsible');
    var instances = M.Collapsible.init(elems, {});
}

var Main = {
    initializeNav: initializeNav,
    initializeCollapsible: initializeCollapsible
}