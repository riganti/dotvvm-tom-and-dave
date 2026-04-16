const extractDotVVMClasses = (content) => {
  // Extract regular class names
  const regularClasses = content.match(/class="([^"]*)"/g)?.flatMap(match => {
    const classes = match.match(/class="([^"]*)"/)?.[1];
    return classes ? classes.split(/\s+/) : [];
  }) || [];

  // Extract DotVVM conditional class attributes: class-[classname]="..."
  const conditionalClasses = content.match(/class-([a-zA-Z0-9-:\[\]]+)=/g)?.map(match => {
    return match.match(/class-([a-zA-Z0-9-:\[\]]+)=/)?.[1];
  }).filter(Boolean) || [];
    
  return [...regularClasses, ...conditionalClasses];
};

/** @type {import('tailwindcss').Config} */
export default {
  content: {
    files: [
      './Pages/**/*.{dothtml,dotmaster,dotcontrol}',
      './Controls/**/*.{dothtml,dotmaster,dotcontrol}',
    ],
    extract: {
      dothtml: extractDotVVMClasses,
      dotmaster: extractDotVVMClasses,
      dotcontrol: extractDotVVMClasses,
    },
  },
  theme: {
    colors: {
      transparent: 'transparent',
      current: 'currentColor',
      white: 'rgb(var(--color-white-rgb))',
      black: '#000000',

      // Semantic colors with opacity support
      primary: {
        DEFAULT: 'rgb(var(--color-primary-500-rgb))',
        50: 'rgb(var(--color-primary-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-primary-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-primary-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-primary-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-primary-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-primary-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-primary-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-primary-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-primary-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-primary-900-rgb) / <alpha-value>)',
      },
      secondary: {
        DEFAULT: 'rgb(var(--color-secondary-500-rgb))',
        50: 'rgb(var(--color-secondary-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-secondary-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-secondary-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-secondary-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-secondary-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-secondary-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-secondary-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-secondary-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-secondary-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-secondary-900-rgb) / <alpha-value>)',
      },
      success: {
        DEFAULT: 'rgb(var(--color-success-500-rgb))',
        50: 'rgb(var(--color-success-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-success-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-success-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-success-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-success-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-success-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-success-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-success-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-success-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-success-900-rgb) / <alpha-value>)',
      },
      warning: {
        DEFAULT: 'rgb(var(--color-warning-500-rgb))',
        50: 'rgb(var(--color-warning-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-warning-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-warning-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-warning-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-warning-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-warning-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-warning-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-warning-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-warning-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-warning-900-rgb) / <alpha-value>)',
      },
      danger: {
        DEFAULT: 'rgb(var(--color-danger-500-rgb))',
        50: 'rgb(var(--color-danger-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-danger-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-danger-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-danger-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-danger-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-danger-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-danger-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-danger-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-danger-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-danger-900-rgb) / <alpha-value>)',
      },
      info: {
        DEFAULT: 'rgb(var(--color-info-500-rgb))',
        50: 'rgb(var(--color-info-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-info-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-info-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-info-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-info-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-info-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-info-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-info-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-info-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-info-900-rgb) / <alpha-value>)',
      },
      gray: {
        DEFAULT: 'rgb(var(--color-gray-500-rgb))',
        50: 'rgb(var(--color-gray-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-gray-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-gray-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-gray-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-gray-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-gray-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-gray-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-gray-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-gray-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-gray-900-rgb) / <alpha-value>)',
      },
      light: {
        DEFAULT: 'rgb(var(--color-light-300-rgb))',
        50: 'rgb(var(--color-light-50-rgb) / <alpha-value>)',
        100: 'rgb(var(--color-light-100-rgb) / <alpha-value>)',
        200: 'rgb(var(--color-light-200-rgb) / <alpha-value>)',
        300: 'rgb(var(--color-light-300-rgb) / <alpha-value>)',
        400: 'rgb(var(--color-light-400-rgb) / <alpha-value>)',
        500: 'rgb(var(--color-light-500-rgb) / <alpha-value>)',
        600: 'rgb(var(--color-light-600-rgb) / <alpha-value>)',
        700: 'rgb(var(--color-light-700-rgb) / <alpha-value>)',
        800: 'rgb(var(--color-light-800-rgb) / <alpha-value>)',
        900: 'rgb(var(--color-light-900-rgb) / <alpha-value>)',
      },
    },
    extend: {
      fontFamily: {
        'sans': ['system-ui', '-apple-system', 'BlinkMacSystemFont', 'Segoe UI', 'Roboto', 'Helvetica Neue', 'Arial', 'sans-serif'],
      },
      backgroundColor: {
        'DEFAULT': 'rgb(var(--color-light-300-rgb))',
      },
    },
  },
  plugins: [],
}
