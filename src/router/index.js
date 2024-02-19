import { createRouter, createWebHistory } from 'vue-router';

const routes = [
	{
		path: '/',
		name: '/',
		component: () => import('../components/Homepage/HomePage.vue'),
	},
	// {
	// 	path: '/about',
	// 	name: 'about',
	// 	// route level code-splitting
	// 	// this generates a separate chunk (about.[hash].js) for this route
	// 	// which is lazy-loaded when the route is visited.
	// 	component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
	// },
	{
		path: '/Signup',
		name: 'SignupPage',
		component: () => import('../components/Homepage/SignupPage.vue')
	},
    {
		path: '/Login',
		name: 'LoginPage',
		component: () => import('../components/Homepage/LoginPage.vue')
	},
	{
		path: '/Status',
		name: 'OrderStatus',
		component: () => import('../components/Homepage/OrderStatus.vue')
	},
	{
		path: '/Phones',
		name: 'Phones Page',
		component: () => import('../components/Phones/PhonesPage.vue')
	},
	{
		path: '/SmartWatch',
		name: 'SmartWatch Page',
		component: () => import('../components/SmartWatch/SmartWatchPage.vue')
	},
	{
		path: '/Laptops',
		name: 'Laptops Page',
		component: () => import('../components/Laptops/LaptopPage.vue')
	},
	{
		path: '/Refrigerators',
		name: 'Refrigerators Page',
		component: () => import('../components/Refrigerators/RefrigeratorsPage.vue')
	},
	{
		path: '/Air_conditioner',
		name: 'Air Conditioner Page',
		component: () => import('../components/AirConditioner/AirConditionerPage.vue')
	},
	{
		path: '/Tablets',
		name: 'Tablets Page',
		component: () => import('../components/Tablets/TabletsPage.vue')
	},
	{
		path: '/SmartTv',
		name: 'SmartTv Page',
		component: () => import('../components/SmartTv/SmartTvPage.vue')
	},
	{
		path: '/WashingMachine',
		name: 'WashingMachine Page',
		component: () => import('../components/WashingMachine/WashingMachinePage.vue')
	},
	{
		path: '/Phone_Brands',
		name: 'Phone Brands',
		component: () => import('../components/Phones/PhoneBrands.vue')
	},
	{
		path: '/SmartTv_Brands',
		name: 'SmartTv Brands',
		component: () => import('../components/SmartTv/SmartTvBrands.vue')
	},
	{
		path: '/SmartWatch_Brands',
		name: 'SmartWatch Brands',
		component: () => import('../components/SmartWatch/SmartWatchBrands.vue')
	},
	{
		path: '/Tablet_Brands',
		name: 'Tablet Brands',
		component: () => import('../components/Tablets/TabletBrands.vue')
	},
	{
		path: '/Laptop_brands',
		name: 'Laptop Brands',
		component: () => import('../components/Laptops/LaptopBrands.vue')
	},
	{
		path: '/Refrigerator_Brands',
		name: 'Refrigerator Brands',
		component: () => import('../components/Refrigerators/RefrigeratorBrands.vue')
	},
	{
		path: '/AC_Brands',
		name: 'Ac Brands',
		component: () => import('../components/AirConditioner/AcBrands.vue')
	},
	{
		path: '/WashingMachine_Brands',
		name: 'WashingMachine Brands',
		component: () => import('../components/WashingMachine/WashingMachineBrands.vue')
	},
	{
		path: '/Ac_Services',
		name: 'AC Services',
		component: () => import('../components/RepairService/AirConditionerServices.vue')
	},
	{
		path: '/Laptop_Services',
		name: 'Laptop Services',
		component: () => import('../components/RepairService/LaptopServices.vue')
	},
	{
		path: '/Phone_Services',
		name: 'Phone Services',
		component: () => import('../components/RepairService/PhoneServices.vue'),
	},
	{
		path: '/Refrigerator_Services',
		name: 'Refrigetrator Services',
		component: () => import('../components/RepairService/RefrigeratorServices.vue')
	},
	{
		path: '/SmartTv_Services',
		name: 'SmartTv Services',
		component: () => import('../components/RepairService/SmartTvServices.vue')
	},
	{
		path: '/SmartWatch_Services',
		name: 'SmartWatch Services',
		component: () => import('../components/RepairService/SmartWatchServices.vue')
	},
	{
		path: '/Tablet_Services',
		name: 'Tablet Services',
		component: () => import('../components/RepairService/TabletServices.vue')
	},
	{
		path: '/WashingMachine_Services',
		name: 'WashingMachine Services',
		component: () => import('../components/RepairService/WashingMachineServices.vue')
	},
	{
		path: '/TrackingPage',
		name: 'Order Tracking',
		component: () => import('../components/Homepage/TrackingPage.vue')
	},
];

const router = createRouter({
	history: createWebHistory(process.env.BASE_URL),
	routes,
});

export default router;
