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

const showToast = (msg, type) => {
    $.notify(msg, type);
}

const triggerAreYouSure = () => {
    swal("Are you sure?", {
        dangerMode: true,
        buttons: true,
    });
}

const SelectId = (modalId, id) => {
    console.log(modalId);
    document.getElementById(modalId).setAttribute("data-eltId", id)
}

const GetSelectedId = (modalId) => {
    return document.getElementById(modalId).getAttribute("data-eltId")
}

const ModalClose = (modalId) => {
    MicroModal.close(modalId);
}




var Main = {
    initializeEditor: initializeEditor,
    GetCode: GetCode,
    showToast: showToast,
    triggerAreYouSure: triggerAreYouSure,
    SelectId: SelectId,
    GetSelectedId: GetSelectedId,
    ModalClose: ModalClose
}