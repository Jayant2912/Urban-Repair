<template>
  <div class="">
    <h2>ORDER STATUS </h2>
    <b> {{this.Status }}</b>
   
  </div>
  <br/>
      <div class="login-home-page">
          <div class="login-part-1">
        <table>
          <thead>
            <tr>
              <th>#</th>
              <th>Device Name</th>
              <th>Service Name</th>
              <th>Invoice Number</th>
              <th>Reciept Number</th>
              <th>Order Date</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, index) in tableData" >
              <td>{{index+1}}</td>
              <td>{{item.DeviceName}}</td>
              <td>{{item.ServiceName}}</td>
              <td>{{item.InvoiceNumber}}</td>
              <td>{{item.RecieptVoucherNumber}}</td>
              <td>{{formatDate(item.CreatedDate)}}</td>
    
            </tr>
          </tbody>
        </table>
          </div> 
      </div>
   
      <div>
   
  </div>
</template>

<script>
import axios from 'axios'
import dayjs from 'dayjs';
export default {
name: "login",
data() {
  return {
        OrderNumber: '',
        InvoiceDate:'',
        InvoiceNumber: '',
        TotalCost:'',
        Device:[],
        Status:'',
        tableData:[]
  };
},
methods: {
      getStatus(createDate)
      {
        const options = {
  weekday: "long",
  year: "numeric",
  month: "long",
  day: "numeric",
};

        const date = dayjs(createDate);
        let deliveryDate1 = new Date(date.add(5, 'day')).toLocaleString('en-IN',options)
        let deliveryDate2 = new Date(date.add(8, 'day')).toLocaleString('en-IN',options)

        return 'Expected delivery date '+  deliveryDate1 +' - ' + deliveryDate2 +' .'
      },
      formatDate(dateString) {
            const date = dayjs(dateString);
                // Then specify how you want your dates to be formatted
            return date.format('dddd MMMM D, YYYY');
        },
      fetchData() {
      axios.get('http://localhost:5047/api/device/GetOrderStatusDetails?searchtext='+sessionStorage.getItem("Email"))
        .then((response) => {
          const grouped = {};
           
            // response.data.forEach((item,index) => {
            // if (!grouped[item.DeviceCode]) {
            //   grouped[item.DeviceCode] = [];
            // }
            //   grouped[item.DeviceCode].push({item:item});
            //    });
          this.tableData=response.data;
          // this.Device = response.data[0];
          // this.InvoiceNumber=this.Devices.InvoiceNumber;
          // this.OrderNumber=this.Devices.RecieptVoucherNumber;
          // this.InvoiceDate = this.Devices.CreatedDate;
          // this.TotalCost = Number(this.Devices.TotalCost) +Number(this.Devices.TotalCost*0.1) ;
          // debugger
           this.Status = this.getStatus(this.tableData[0].CreatedDate)
        })
        .catch((error) => {
          console.error('Error fetching data:', error);
        });
      },
    },

    created() {
      this.fetchData();     
      
    },
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
table,tr,td,th{
  border: 1px solid;
}
th{
  font-weight: 600;
}
.login-part-1{
  text-align: -webkit-center;
  background-color: aliceblue;
}
</style>
