const initializeNav = () => {
        var elems = document.querySelectorAll('.sidenav');
        var instances = M.Sidenav.init(elems, {});
}

const initializeCollapsible = () => {
    var elems = document.querySelectorAll('.collapsible');
    var instances = M.Collapsible.init(elems, {});
}

const initializeFormSelect = () => {
    var elems = document.querySelectorAll('select');
    var instances = M.FormSelect.init(elems, {});
}



var Main = {
    initializeNav: initializeNav,
    initializeCollapsible: initializeCollapsible,
    initializeFormSelect: initializeFormSelect
}