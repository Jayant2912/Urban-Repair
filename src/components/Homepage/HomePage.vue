<template>
  <div class="home-page-layout" >

    <div class="home-page-repair">
      <div class="home-page-repair-image-text">
        <div>
      <div class="repair-heading">Repair at your door step</div>
    </div>
      <div class="repair-detail-lines">Trained Professionals</div>
      <div class="repair-detail-lines">Doorstep Service</div>
      <div class="repair-detail-lines">6 months warranty</div>
    </div>
      <img class="home-page-repair-image" src='@/assets/HomeImages/repair_robot.jpg'>
    </div>

    <div class="steps-division-main">
      <div class="steps-heading">
        <div style="text-align: center; margin-right:134px">Steps</div>
      </div>
      <div class="steps-horizontal-layout" >
        <img style="height: 400px; margin-right: 28px;" src='@/assets/HomeImages/note_robots.jpg'>
        <div class="step">
          <p>1.</p>
          <p>Fill in your service request and submit</p>
        </div>
        <div class="step">
          <P>2.</P>
          <p>Use our pick-up service to ship your device or visit our service center</p>
        </div>
        <div class="step">
          <p>3.</p>
          <p>Service Center will inspect and repair your device</p>
        </div>
        <div class="step">
          <p>4.</p>
          <p>Collect the repaired device and rate our services</p>
        </div>
      </div>
    </div>

    <div class="services-main-layout">
      <div class="sevices-head">Choose Your Desired Service</div>
      <div class="services-function">
        <div class="service-category">
          <img style="height: 100px;" src='@/assets/HomeImages/service_man.png'>
          <label for="category">Category</label>
          <select name="category" id="category" ref="categorySelect">
            <option value="Phones">Phones</option>
            <option value="Smart Tv">Smart Tv's</option>
            <option value="Smart Watch">Smart Watch</option>
            <option value="Tablets">Tablets</option>
            <option value="Laptops">Laptops</option>
            <option value="Refrigerators">Refrigerators</option>
            <option value="Air conditioners">Air conditioners</option>
            <option value="Washing Machines">Washing Machines</option>
          </select>
          <input type="submit" value="submit" id="submit" @click="handleSubmit">
        </div>
      </div>
    </div>

    <div class="note-division">
      <div class="note-heading">Customer Care Guidelines for a Smooth Repair Experience</div>
        <div class="note-division-details">
        <div>
          <div id="note-list">&#8226; Please back up all personal data on your device.</div>
          <div id="note-list">&#8226; To protect your personal data, please remove the security lock and reset your device.</div>
          <div id="note-list">&#8226; Battery replacements may require your device to be reset. Ensure you back up all personal data before bringing it in for service.</div>
          <div id="note-list">&#8226; In case of water damage, power off your device and bring it to us immediately. Swift action can increase the chances of a successful repair.</div>
          <div id="note-list">&#8226; Ensure compatibility of third-party accessories. Non-compatible accessories can cause damage and void warranty. Ask our experts for guidance.</div>
          <div id="note-list">&#8226; To keep your AC, fridge, or washing machine running smoothly, consider scheduling regular maintenance. Our experts are here to help you maintain your appliances in top condition.</div>
          <div id="note-list">&#8226; Before booking a repair service, please ensure the appliance is free from any perishables or items that could affect the technician's work. This helps us serve you more efficiently.</div>  
        </div>
        <img style="height: 420px;"  src='@/assets/HomeImages/steps_robot.jpg'>
      </div>
    </div>

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
          How long will the repair take?
        </div>
        <div class="answers-faqs">{{symbol[0]}}</div>
      </div>
      <div><p class="Answer"  v-html="variable[0]"></p> {{ item }}</div>
      </div>
      <div>
      <div class="question-division" @click="handleAnswer(1)">
        <div class="question-image-divison">
          <img class="question-image" src='@/assets/HomeImages/question_final.png'>
        </div>
        <div class="questions-faqs">
          How to get my device prepared for repair ?
        </div>
        <div class="answers-faqs">{{symbol[1]}}</div>
      </div>
      <div><p class="Answer"  v-html="variable[1]"></p></div>
    </div>
    <div>
      <div class="question-division" @click="handleAnswer(2)">
        <div class="question-image-divison">
          <img class="question-image" src='@/assets/HomeImages/question_final.png'>
        </div>
        <div class="questions-faqs">
          How do i know if my device is under warrenty ?
        </div>
        <div class="answers-faqs">{{symbol[2]}}</div>
      </div>
      <div><p class="Answer"  v-html="variable[2]"></p></div>
    </div> 
    <div>
      <div class="question-division"  @click="handleAnswer(3)">
        <div class="question-image-divison">
          <img class="question-image" src='@/assets/HomeImages/question_final.png'>
        </div>
        <div class="questions-faqs">
          How to check status of my repair ?
        </div>
        <div class="answers-faqs">{{symbol[3]}}</div>
      </div>
      <div><p class="Answer" v-html="variable[3]"  ></p></div>
    </div>
    <div>
      <div class="question-division"  @click="handleAnswer(4)">
        <div class="question-image-divison">
          <img class="question-image" src='@/assets/HomeImages/question_final.png'>
        </div>
        <div class="questions-faqs">
          What is pick-up &#38; drop service and How can i avail it ?
        </div>
        <div class="answers-faqs">{{symbol[4]}}</div>
      </div>
      <div><p class="Answer" v-html="variable[4]" ></p></div>
    </div>
    </div>
    
  </div>
</template>
<script>
import '@/assets/StyleSheet/HomePage/home-page-layout.css'
import '@/assets/StyleSheet/HomePage/services.css'
import '@/assets/StyleSheet/HomePage/faqs-division.css'
import '@/assets/StyleSheet/HomePage/bottom-division.css'
var symbol;
  export default {
  name: 'HomePage',
  data() {
    return {
      variable:['','','','',''],
      symbol:['+','+','+','+','+'],
      isOpen: false,
      answerText: [
        'It usually takes 1-2 hour for walk in repair and 5 to 7 days for pickup repair from the time we receive the device , depending upon yourlocation and part of avalability',
        'Please back up all personal data on your device. Data might be lost during repairing; if you did not back it up for any reason, we will not be responsible for lost data.Before proceeding with the repair, we will ask for your approval to erase the data if required via phone call.In case you are unavailable, we will not proceed until we have a response from you. This might increase the time required for repair.',
        'Products purchased online come with a limited warranty of one (1) year starting from the date of delivery.',
        'You can check the current status of your repair by visiting https://www.repairCenter.in/support/repair or repairCenter Store APP.',
        'Pick-up and drop service allows you to ship your device to the nearest selected service centre through authorised logistics for free. Once the device has been repaired, we will also ship back the device to your address.To avail this service, just input the required information while raising service request on https://www.repairCenter.in/support/repair or repairCenter Store APP',
      ],
    };
  },
  methods: {
    handleSubmit() {
      const selectedValue = this.$refs.categorySelect.value;
      if (selectedValue === 'Phones') {
        window.location.href = '/Phones';
      } else if (selectedValue === 'Smart Tv') {
        window.location.href = '/SmartTv';
      } else if (selectedValue === 'Smart Watch') {
        window.location.href = '/SmartWatch';
      } else if (selectedValue === 'Tablets') {
        window.location.href = '/Tablets';
      } else if (selectedValue === 'Laptops') {
        window.location.href = '/Laptops';
      } else if (selectedValue === 'Refrigerators') {
        window.location.href = '/Refrigerators';
      } else if (selectedValue === 'Air conditioners') {
        window.location.href = '/Air_conditioner';
      } else if (selectedValue === 'Washing Machines') {
        window.location.href = '/WashingMachine';
      }
    },
    handleAnswer(index){
      if (!this.isOpen) {
        this.variable[index]=this.answerText[index];
        this.symbol[index]="-";
        this.isOpen =true;
      } else {
        this.variable[index] = '';
        this.symbol[index]="+";
        this.isOpen = false;
      }
    },
  },
};
</script>
