import React from 'react';

import Navigation from '../Navigation/Navigation';

const layout = (props) => {
    return(
        <div className="container">
            <div className="row">
                <Navigation/>
            </div>
            <main>
                {props.children}
            </main>
        </div>
      
    )
}

export default layout;