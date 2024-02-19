<template>
    <div class="login-home-page">
        <div class="login-part-1">
            <img class="login-image-1" src="@/assets/HomeImages/new_account.jpg">
        </div> 
        <div class="login-page">
        <div class="login-page-details">
                <div class="login-page-heading">Login Details</div>
                <div class="login-details">
                    <input id="login-user-id" v-model="email" type="text" placeholder="Email Address">
                    <input id="login-user-password" v-model="password" type="password" placeholder="Password">
                </div>
                <div class="login-button-div">
                    <button @click="login" class="login-button">Login</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
name: "login",
data() {
    return {
        email: "",
        password: ""
    };
},
methods: {
    async login() {
        try {
            const userData = {
                Email: this.email,
                Password: this.password
            };
            const response = await axios.post(
                'http://localhost:5047/User/UserLogin',
                userData, {
                headers: {
                    'Content-Type': 'application/json'
                    }
                }
            );
            const data = response.data;
            if (data && data.isVerified) {
                const sessionStorage = window.sessionStorage;
                sessionStorage.setItem("UserName", data.userName);
                sessionStorage.setItem("Email", data.email);
                sessionStorage.setItem("IsVerified", data.isVerified);
                this.$router.push('/')
            }
            console.log(data); 
            } catch (error) {
            console.error('An error occurred:', error);
            }
        }
    }
}
</script>

<style>

.login-page-details {
    position: absolute;
    top: 200px;
    right: 460px;
    left: 460px;
}

.login-page-heading {
    color: rgb(110 94 184);
    height: 44px;
    border-radius: 5px;
    margin-left: 17px;
    margin-bottom: 26px;
    text-align: center;
    font-size: 41px;
    padding-top: 6px;
    padding-right: 4px;
    font-family: Arial, Helvetica, sans-serif;
}

.login-details {
    display: flex;
    flex-direction: column;
    height: 143px;
    width: 280px;
    margin-left: 35px;
    font-family: Arial, Helvetica, sans-serif;
    vertical-align: middle;
}

#login-user-id {
    padding: 15px;
    margin-bottom: 10px;
    margin-top: 2px;
    border: 1px solid grey;
    border-radius: 5px;
    height: 50px;
    background-color: rgb(240, 223, 255);
}

#login-user-password {
    padding: 15px;
    margin-bottom: 10px;
    margin-top: 2px;
    border: 1px solid grey;
    border-radius: 5px;
    height: 50px;
    background-color: rgb(240, 223, 255);
}

.login-button-div {
    margin-top: 0;
}

.login-button {
    background-color: rgb(67 41 108);
    color: white;
    font-size: large;
    border: none;
    border-radius: 8px;
    width: 125px;
    height: 44px;
    margin-left: 5px;
}
</style>
