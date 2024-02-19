const sampleDataTableData = {
    headings: [
        "Name",
        "Job",
        "Company"
    ],
    data: [
        [
            "Hedwig F. Nguyen",
            "Manager",
            "Arcu Vel Foundation"
        ],
        [
            "Genevieve U. Watts",
            "Manager",
            "Eget Incorporated"

        ],
        [
            "Kyra S. Baldwin",
            "Manager",
            "Lorem Vitae Limited"

        ],
        [
            "Stephen V. Hill",
            "Manager",
            "Eget Mollis Institute"

        ],
        [
            "Vielka Q. Chapman",
            "Manager",
            "Velit Pellentesque Ultricies Institute"

        ],
        [
            "Ocean W. Curtis",
            "Manager",
            "Eu Ltd"

        ],
        [
            "Kato F. Tucker",
            "Manager",
            "Vel Lectus Limited"

        ],
        [
            "Robin J. Wise",
            "Manager",
            "Curabitur Dictum PC"

        ],
        [
            "Uriel H. Guerrero",
            "Assistant",
            "Mauris Inc."

        ],
        [
            "Yasir W. Benson",
            "Assistant",
            "At Incorporated"

        ]
    ]
};
var mySimpleDatatables = {};


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


const InitDataTable = (eltId, json, modalRemoveId) => {
    if (mySimpleDatatables[eltId] !== undefined) {
        mySimpleDatatables[eltId].destroy();
    }

    let btnGroup = `<div style="text-align:center;" >
        <a href="%linkUpdate%" class="btn waves-effect waves-light" >
            <i class="material-icons left">edit</i> Update
        </a>
        <button class="btn waves-effect waves-light red modal-trigger"
                data-target="${modalRemoveId}"
                onclick="Main.SelectId('${modalRemoveId}', %EltId%)">
            <i class="material-icons left">cancel</i> Remove
        </button>
    </div>`;

    //console.log(json)
    json.data.map(el => {
        const linkUpdate = el[el.length - 1];
        let id = linkUpdate.split("/");
        id = id[id.length - 1];
        btnGroup = btnGroup.replace("%linkUpdate%", linkUpdate)
        el[el.length - 1] = btnGroup.replace("%EltId%", id)
    }
    )
    mySimpleDatatables[eltId] = new simpleDatatables.DataTable(`#${eltId}`, {
        //data:  sampleDataTableData 
        data: json
    })

}

const DestroyDataTable = (eltId) => {
    mySimpleDatatables[eltId].destroy();
}

const InitDropdown = (options) => {

    const container = document.getElementById(options.containerId);
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems, { container: container, ...options });
}

const InitTabs = () => {
    var elems = document.querySelectorAll('.tabs');
    var instance = M.Tabs.init(elems, {});
}

const InitModal = () => {
    var elems = document.querySelectorAll('.modal');
    var instances = M.Modal.init(elems, {});
}




var MaterializeInitializer = {
    initializeNav: initializeNav,
    initializeCollapsible: initializeCollapsible,
    initializeFormSelect: initializeFormSelect,
    InitDataTable: InitDataTable,
    DestroyDataTable: DestroyDataTable,
    InitDropdown: InitDropdown,
    InitTabs: InitTabs,
    InitModal: InitModal
}