﻿class AuthenRepo extends BaseRepo {
    header = "";
    constructor(token) {
        super();
        this.header = {
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            }
        }
    }

    SignIn(loginRequestModel) {
        try
        {
            const response = axios.post(this.BaseUrl + "/api/v1/authen/login", JSON.stringify(loginRequestModel), this.header).then((response) => {
                return response.data.data.accessToken;
            });
           
        } catch (error) {
            console.error(error);
        }
    }

    Registers(registerModel) {
        try {
            console.log(JSON.stringify(registerModel));
            const response = axios.post(this.BaseUrl + "/authen/register", JSON.stringify(registerModel), this.header).then((response) => {
                return response.data;
            });

        } catch (error) {
            console.error(error);
        }
    }
}
