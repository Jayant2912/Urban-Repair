<template>
<div class="faqs-division">
    <div class="question-dividion-heading">
        FAQS
    </div>
    <div>
        <div class="question-division" @click="handleAnswer(0)">
            <div class="question-image-divison">
                <img class="question-image" src='@/assets/HomeImages/question_final.png'>
            </div>
            <div class="questions-faqs">
                What happens when I place an order?
            </div>
            <div class="answers-faqs">{{symbol[0]}}</div>
        </div>
        <div>
            <p class="Answer" v-html="variable[0]"></p> {{ item }}
        </div>
    </div>
    <div>
        <div class="question-division" @click="handleAnswer(1)">
            <div class="question-image-divison">
                <img class="question-image" src='@/assets/HomeImages/question_final.png'>
            </div>
            <div class="questions-faqs">
                How do I pay for my order?
            </div>
            <div class="answers-faqs">{{symbol[1]}}</div>
        </div>
        <div>
            <p class="Answer" v-html="variable[1]"></p>
        </div>
    </div>
    <div>
        <div class="question-division" @click="handleAnswer(2)">
            <div class="question-image-divison">
                <img class="question-image" src='@/assets/HomeImages/question_final.png'>
            </div>
            <div class="questions-faqs">
                How Will I Get An Invoice For The Service?
            </div>
            <div class="answers-faqs">{{symbol[2]}}</div>
        </div>
        <div>
            <p class="Answer" v-html="variable[2]"></p>
        </div>
    </div>
</div>
</template>

<script>
export default {
    data() {
        return {
            variable: ['', '', ''],
            symbol: ['+', '+', '+'],
            isOpen: false,
            answerText: [
                'Once the order is placed, our support team contacts you to confirm your availability for the service & an executive is assigned for your order. The executive will reach your location at a preferred time & repair your device.',
                'Once the repair is completed by our technician, you can pay using the following methods: Cash, Paytm, UPI or Credit/Debit Card.',
                'Once the repair order is completed, you will get an email with an invoice in the attachment. The invoice will have the amount charged for the order and can be used later to claim the warranty.',
            ],
        }
    },
    methods: {
        handleAnswer(index) {
            if (!this.isOpen) {
                this.variable[index] = this.answerText[index];
                this.symbol[index] = "-";
                this.isOpen = true;
            } else {
                this.variable[index] = '';
                this.symbol[index] = "+";
                this.isOpen = false;
            }
        },
    }
}
</script>

<style>

</style>
