/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./**/*.dothtml",
        "./**/*.dotmaster",
        "./**/*.dotcontrol",
    ],
  theme: {
    extend: {},
  },
  plugins: [require('@tailwindcss/typography')],
}

