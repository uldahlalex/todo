import {defineConfig, type UserConfig} from 'vite'
import react from '@vitejs/plugin-react'

let userConfig: UserConfig = defineConfig({
    plugins: [react()],
});
export default userConfig;
