<script>
export default {
     data() {
        let Email = sessionStorage.getItem('Email');
        let isUserLoggedIn
        if(Email && Email!=undefined)
        {
         isUserLoggedIn= true;
        }
        else
        isUserLoggedIn = false;
        
        return {
            isUserLoggedIn
        }
    },
     
}
</script>