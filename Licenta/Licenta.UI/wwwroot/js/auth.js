
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


var Auth = {
    handleLogin: handleLogin,
    handleLogout: handleLogout,
};