import { RecoilRoot } from 'recoil';
import '@/styles/globals.css';
import React from 'react';

export default function App({ Component, pageProps }) {
    return (
        <RecoilRoot>
            <Component {...pageProps} />
        </RecoilRoot>
    );
}
