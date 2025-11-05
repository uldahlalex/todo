import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
let userConfig = defineConfig({
    plugins: [react()],
});
export default userConfig;
