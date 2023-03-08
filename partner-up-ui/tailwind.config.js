module.exports = {
    content: [
        './app/**/*.{js,ts,jsx,tsx}',
        './pages/**/*.{js,ts,jsx,tsx}',
        './components/**/*.{js,ts,jsx,tsx}',
        './src/**/*.{js,ts,jsx,tsx}',
    ],
    plugins: [require('daisyui')],
    theme: {},
    daisyui: {
        themes: [
            'lofi',
            'black',
        ],
        darkTheme: 'black',
    },
};
