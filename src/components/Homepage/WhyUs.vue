<template>
<div>
    <div class="whyus-heading">Why Us</div>
    <div>
        <div class="main-wrap" v-for="(WhyUs, index) in WhyUsHead" :style=" index === 5 ? 'margin-left:17px;' :'' ">
            <div class="whyus-templates">
                <div>
                    <img class="whyus-image" :src="GetWhyUsImage(index)">
                </div>
                <div class="whyus-details">
                    <div class="whyus-details-inner">{{ WhyUsHead[index] }}</div>
                    <div>{{ WhyUsDetails[index] }}</div>
                </div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
export default {
    data() {
        return {
            WhyUsDetails: [
                'Top quality certified parts',
                'Repair on the Spot in Delhi Repair Store or at Home',
                'Free 1 Month Replacement even if it breaks for all Repair',
                'Hassle free 6 month warranty on parts replaced',
                'Trained & Qualified Professionals',
                'Total Device & Data Security',
            ],
            WhyUsHead: [
                'Premium Repair',
                'Instant Repair',
                'Physical Protection Warranty',
                '6 Months Warranty',
                'Skilled Technicians',
                'Guaranteed Safety',
            ],
            WhyUsImage: [
                'price-tag.png',
                'loan.png',
                'shield.png',
                'worker.png',
                'coordination.png',
                'warranty.png',
            ],
        }
    },
    methods: {
        GetWhyUsImage(index) {
            return require(`@/assets/WhyUs_img/${this.WhyUsImage[index]}`);
        }
    }
}
</script>

<style>
.whyus-heading {
    font-weight: 600;
    font-size: 48px;
    margin-bottom: 10px;
}

.main-wrap {
    display: inline-block;
    width: 410px;
}

.whyus-templates {
    display: flex;
    margin-bottom: 17px;
    margin-right: 22px;
}

.whyus-image {
    height: 100px;
    margin-right: 10px;
}

.whyus-details {
    text-align: start;
}

.whyus-details-inner {
    font-weight: 600;
    font-size: 18px;
}
</style>
