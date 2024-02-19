<template>
    <div class="Model-page-main-container">
        <div class="Model-page-templates">
            <img style="height: 100px;" src="@/assets/ModelComp_img/contract.png">
            <div class="Model-page-templates-text">
                <div class="Model-page-templates-text-head">&#9312; Check Price</div>
                <div class="Model-page-templates-text-detail">Select your device that needs to be repaired. Get best Pricing.</div>
            </div>
        </div>
        <div class="Model-page-templates">
            <img style="height: 100px;" src="@/assets/ModelComp_img/delivery.png">
            <div class="Model-page-templates-text">
                <div class="Model-page-templates-text-head">&#9313; Schedule Service</div>
                <div class="Model-page-templates-text-detail">Book a free technician visit at your home or work at a time slot that best suits your convenience.</div>
            </div>
        </div>
        <div class="Model-page-templates">
            <img style="height: 100px;" src="@/assets/ModelComp_img/mechanic2.png">
            <div class="Model-page-templates-text">
                <div class="Model-page-templates-text-head">&#9314; Get Device Repaired</div>
                <div class="Model-page-templates-text-detail">Our super-skilled technician will be there and make it as good as new.</div>
            </div>
        </div>
    </div>
</template>


<style>
.Model-page-main-container{
    display: flex;
    justify-content: space-between;
    margin-top: 10px;
    background-color: rgb(232, 244, 255);
}
.Model-page-templates{
    padding: 10px 10px 10px 10px;
    display: inline-block;
    height: 240px;
    width: 340px;
}
.Model-page-templates-text{
    color: #08192b;
    margin-left: 10px;
}
.Model-page-templates-text-head{
    font-size: 28px;
    text-align: initial;
    vertical-align: middle;
    font-weight: 600;
}
.Model-page-templates-text-detail{
    font-size: large;
    text-align: start;
}
</style>