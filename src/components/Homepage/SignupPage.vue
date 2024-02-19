<template>
<div class="signup-home-page">
    <div class="signup-part-1">
        <img class="signup-image-1" src="@/assets/HomeImages/new_account.jpg">
    </div> 
    <div class="signup-page">
    <div class="signup-page-details">
            <div class="signup-page-heading">Create Account</div>
            <div class="signup-details">
                <input id="signup-user-name" v-model="name" type="text" placeholder="Name">
                <input id="signup-user-id" v-model="email" type="text" placeholder="Email Address">
                <input id="signup-user-password" v-model="password" type="password" placeholder="Password">
                <input id="signup-user-Address" v-model="address" type="text" placeholder="Address">
            </div>
            <div class="signup-button-div">
                <button @click="signup" class="signup-button">SignUp</button>
            </div>
        </div>
    </div>
</div>

</template>
<script>
 import axios from 'axios'
export default {
    data() {
        return {
            name: '',
            email: '',
            password: '',
            address:'',
        }
    },
    methods: {
        async signup() {
            try {
                let headers = {
                    'Content-Type': 'application/json;charset=utf-8'
                };
                let data = {
                    name:this.name,
                    password:this.password,
                    email:this.email,
                    address:this.address
                }
                axios.post('http://localhost:5047/User/UserRegister',data, {
                        headers
                    })
                    .then(this.extractData)
                    .catch(this.handleError);
                alert('Registration successful');
                this.$router.push('/')
                } catch (error) {
                    console.error(error);
                }
        }
    }
}
</script>

<style>
.signup-image-1 {
    position: relative;
    max-width: 100%;
}

.signup-image {
    position: relative;
    max-width: 100%;
}

.signup-page-details {
    position: absolute;
    top: 143px;
    left: 460px;
    right: 460px;
}

.signup-page-heading {
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

.signup-details {
    display: flex;
    flex-direction: column;
    height: 260px;
    width: 300px;
    margin-left: 30px;
    font-family: Arial, Helvetica, sans-serif;
    vertical-align: middle;
}

#signup-user-name {
    padding: 15px;
    margin-bottom: 10px;
    margin-top: 2px;
    border: 1px solid grey;
    border-radius: 5px;
    height: 50px;
    background-color: rgb(240, 223, 255);
}

#signup-user-id {
    padding: 15px;
    margin-bottom: 10px;
    margin-top: 2px;
    border: 1px solid grey;
    border-radius: 5px;
    height: 50px;
    background-color: rgb(240, 223, 255);
}

#signup-user-password {
    padding: 15px;
    margin-bottom: 10px;
    margin-top: 2px;
    border: 1px solid grey;
    border-radius: 5px;
    height: 50px;
    background-color: rgb(240, 223, 255);
}

.signup-button-div {
    margin-top: 0;
}
#signup-user-Address{
    padding: 15px;
    margin-bottom: 10px;
    margin-top: 2px;
    border: 1px solid grey;
    border-radius: 5px;
    height: 50px;
    background-color: rgb(240, 223, 255);
}
.signup-button {
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
