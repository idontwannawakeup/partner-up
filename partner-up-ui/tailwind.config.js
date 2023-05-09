/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './src/pages/**/*.{js,ts,jsx,tsx,mdx}',
        './src/components/**/*.{js,ts,jsx,tsx,mdx}',
        './src/app/**/*.{js,ts,jsx,tsx,mdx}',
    ],
    plugins: [require('daisyui')],
    theme: {},
    darkMode: 'class',
    daisyui: {
        themes: [
            'lofi',
            'black',
        ],
        darkTheme: 'black',
    },
};
