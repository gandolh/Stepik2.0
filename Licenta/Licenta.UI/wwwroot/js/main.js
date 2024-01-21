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

const handleLogin = async () => {
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    const callbackError = (error) => {
        document.getElementById("error-login").innerText = "Perechea email și parolă este invalidă";
    }

    const callbackSucces = () => {
        window.location = window.location.origin;
    }
    const currentHost = window.location.host;
    const url = `https://${currentHost}/api/login`;

    await postData(url, {
        email: email,
        password: password
    }, callbackError, callbackSucces);

}

const handleLogout = async () => {
    const currentHost = window.location.host;
    const url = `https://${currentHost}/api/logout`;

    const callbackError = (error) => {
        console.log(error);
    }

    const callbackSucces = () => {
        window.location = window.location.origin;
    }

    await postData(url, {}, callbackError, callbackSucces);
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


var Main = {
    initializeNav: initializeNav,
    initializeCollapsible: initializeCollapsible,
    initializeFormSelect: initializeFormSelect,
    handleLogin: handleLogin,
    handleLogout: handleLogout,
    initializeEditor: initializeEditor,
    GetCode: GetCode
}


async function postData(url, postData, callbackError, callbackSucces) {
    // Get the current site host

    // Define the URL
    

    try {
        // Make the POST request with await
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postData)
        });

        // Check for errors
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }

        // Parse and handle the response data
        const data = await response.text();
        callbackSucces();
        //console.log('Response data:', data);

    } catch (error) {
        // Handle errors
        callbackError(error);
    }
}
