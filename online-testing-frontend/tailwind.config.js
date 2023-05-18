/** @type {DefaultColors} */

const twColors = require('tailwindcss/colors')

const colors = {
  transparent: twColors.transparent, black: twColors.black, white: twColors.white,
  primary: {
    50: '#f2fbf9',
    100: '#d2f5ee',
    200: '#a6e9df',
    300: '#71d7cb',
    400: '#44bdb3',
    500: '#2aa29a',
    600: '#1f827d',
    700: '#1e6c69',
    800: '#1b5452',
    900: '#1b4645',
    950: '#0a2929',
  },
  'error': '#B00020',
}

module.exports = {
  darkMode: 'class', content: ["./src/**/*.{html,ts}",], theme: {
    extend: {
      colors,
      fontSize: {
        xs: '0.82rem',
        sm: '0.98rem',
        base: '1.15rem',
        lg: '1.22rem',
        xl: '1.36rem',
        '1.5xl': '1.5rem',
        '2xl': '1.725rem',
        '3xl': '2.155rem',
        '4xl': '2.58rem',
        '5xl': '3.45rem',
        '6xl': '4.3rem',
        '7xl': '5.17rem',
        '8xl': '6.9rem',
        '9xl': '9.2rem',
      }, keyframes: {
        animationOpacity: {
          from: {opacity: 0.2}, to: {opacity: 1}
        },
        scaleIn: {
          '0%': {
            opacity: 0,
            transform: 'scale(0.9)'
          },
          '50%': {
            opacity: 0.3
          },
          '100%': {
            opacity: 1,
            transform: 'scale(1)'
          }
        }
      },
      animation: {
        opacity: 'animationOpacity .5s ease-in-out',
        scaleIn: 'scaleIn .35s ease-in-out'
      }
    },
  }, plugins: [],
}
