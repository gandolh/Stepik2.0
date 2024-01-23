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

const initializeEditor = (idElt, value, language) => {
    // Through the options literal, the behaviour of the editor can be easily customized.
    // Here are a few examples of config options that can be passed to the editor.
    // You can also call editor.updateOptions at any time to change the options.
    if (window.editor)
        window.editor.dispose()

    window.editor = monaco.editor.create(document.getElementById(idElt), {
        padding: {
            top: 15
        },
        value: value,
        language: language,

        lineNumbers: "off",
        roundedSelection: false,
        scrollBeyondLastLine: false,
        readOnly: false,
        theme: "vs-dark",
    });
    setTimeout(function () {
        editor.updateOptions({
            lineNumbers: "on",
        });
    }, 2000);


}

const GetCode = () => {
    return window.editor.getValue();
}

const InitDataTable = (eltId, json, modalRemoveId) => {

    const btnGroup = `<div style="text-align:center;" >
        <a href="%linkUpdate%" class="btn waves-effect waves-light" >
            <i class="material-icons left">edit</i> Update
        </a>
        <button class="btn waves-effect waves-light red" onclick="MicroModal.show('${modalRemoveId}');">
            <i class="material-icons left">cancel</i> Remove
        </button>
    </div>`;

    //console.log(json)
    json.data.map(el => el[el.length - 1] = btnGroup.replace("%linkUpdate%", el[el.length - 1]))
    mySimpleDatatables[eltId] = new simpleDatatables.DataTable(`#${eltId}`, {
        //data:  sampleDataTableData 
        data: json
    })
        
}

const DestroyDataTable = (eltId) => {
    mySimpleDatatables[eltId].destroy();
}

const showToast = (msg, type) => {
    $.notify(msg, type);
}

var Main = {
    initializeNav: initializeNav,
    initializeCollapsible: initializeCollapsible,
    initializeFormSelect: initializeFormSelect,
    initializeEditor: initializeEditor,
    GetCode: GetCode,
    InitDataTable: InitDataTable,
    DestroyDataTable: DestroyDataTable,
    showToast: showToast
}

