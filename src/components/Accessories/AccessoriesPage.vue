<template>
    <div class="page-container">
      <div class="sidebar-phone-company">side bar</div>
      <div class="main-content">
        <h1>repair your Tv and Display</h1>
        <h3>select Brand</h3>
      <div class="templates">
        <div class="col-lg-2" v-for="(pic, index) in variable" :key="pic">
          <div class="template-images-div">
            <img class="templates-images" :src="getImageUrl(pic)" :alt="pic">
            <div class="name-div">{{ brand_name[index] }}</div>
          </div>
        </div>
      </div>
    </div>
  </div>
  </template>
  <script>
  export default {
    name: 'TvandDisplay',
    data() {
      return {
        index:0,
        brand_name:['panasonic','samsung','sony','one plus'],
        variable: [
           'panasonic.jpg',
           'samsung.jpg',
           'sony.jpg',
           'one_plus.jpg',
        ],
      };
    },
    methods: {
      getImageUrl(pic) {
        return require(`@/assets/services_logo/${pic}`);
      },
    },
  };
  </script>
  <style>
  .page-container {
    display: flex;
  }
  .sidebar-phone-company {
    position: fixed;
    left: 0;
    width: 100px;
    height: 100%;
    background-color: lightgray;
  }
  .main-content {
    display: flex;
    flex-direction: column;
    margin-left: 100px; 
    padding: 20px;
  }
  .templates{
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    margin-left: 20px; 
  }
  .col-lg-2{
    width: calc(50% - 10px); 
    padding: 5px;
    box-sizing: border-box;
  }
  .template-images-div{
    display: inline;
    height: 110px;
    width: 185px;
  }
  .templates-images{
    display: grid;
    width: 180px;
    height: 230px;
    padding: 10px 10px 10px 10px;
    
  }
  .name-div{
    display: inline-block;
    margin-top: 4px;
    font-family: Arial, Helvetica, sans-serif;
    font-size: larger;
    margin-right: 50px;
  }
  h1, h3 {
    text-align: left;
    
  }
  </style>
  