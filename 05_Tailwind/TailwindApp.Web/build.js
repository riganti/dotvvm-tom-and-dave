import * as esbuild from 'esbuild'
import { sassPlugin } from 'esbuild-sass-plugin'
import postcss from 'postcss'
import tailwindcss from 'tailwindcss'
import autoprefixer from 'autoprefixer'

const settings = {
    entryPoints: [
        'Resources/css/app.scss'
    ],
    bundle: true,
    outdir: 'wwwroot',
    outbase: 'Resources',
    bundle: true,
    minify: true,
    sourcemap: true,
    plugins: [
        sassPlugin({
            async transform(source) {
                const { css } = await postcss([tailwindcss, autoprefixer]).process(source, {
                    from: undefined,
                });
                return css;
            }
        })
    ],
    format: "esm",
    loader: {
        '.ttf': 'file'
    }
};

const context = await esbuild.context(settings);
if (process.argv.includes("--watch")) {
    await context.watch();
} else {
    await context.rebuild();
    await context.dispose();
}