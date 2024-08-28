class AuthenRepo extends BaseRepo {
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
            console.log(JSON.stringify(loginRequestModel))
            debugger; 
            const response = axios.post(this.BaseUrl + "/api/v1/authen/login", JSON.stringify(loginRequestModel), this.header).then((response) => {
                return response.data.data.accessToken;
            });
           
        } catch (error) {
            console.error(error);
        }
    }
}
