
const handleLogin = async (email, password) => {
    var email = email ?? document.getElementById("email").value;
    var password = password ?? document.getElementById("password").value;
    const callbackError = (error) => {
        document.getElementById("error-login").innerText = "Perechea email și parolă este invalidă";
    }

    const callbackSucces = () => {
        window.location = window.location.origin;
    }
    const currentHost = window.location.host;
    const url = `https://${currentHost}/api/login`;

    await postData(url, JSON.stringify({
        email: email,
        password: password
    }), callbackError, callbackSucces);

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

    await postData(url, JSON.stringify({}), callbackError, callbackSucces);
}

const uploadProfilePicture = async () => {
    const currentHost = window.location.host;
    const url = `https://${currentHost}/api/uploadPicture`;

    const fileInput = document.getElementById('uploadProfilePic');
    const formData = new FormData();
    formData.append('file', fileInput.files[0]);

    const callbackError = (error) => {
        console.error(error);
    }

    const callbackSucces = () => {
        console.log('success');
    }

    await postData(url, formData, callbackError, callbackSucces, {});
    window.location.reload();
}

async function postData(url, postData, callbackError, callbackSucces, customHeaders) {
    // Get the current site host

    // Define the URL
    const defaultHeader = {
        'Content-Type': 'application/json'
    }
    const headers = customHeaders ? customHeaders : defaultHeader;

    try {
        // Make the POST request with await
        const response = await fetch(url, {
            method: 'POST',
            headers: headers,
            body: postData
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


var ApiCaller = {
    uploadProfilePicture: uploadProfilePicture
}

var Auth = {
    handleLogin: handleLogin,
    handleLogout: handleLogout,
};