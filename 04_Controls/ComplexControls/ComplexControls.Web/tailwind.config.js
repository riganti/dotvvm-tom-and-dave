/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Pages/**/*.{dothtml,dotmaster,dotcontrol,html}",
    "./Views/**/*.{dothtml,dotmaster,dotcontrol,html}",
    "./Controls/**/*.{dothtml,dotmaster,dotcontrol,html,cs}"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}

