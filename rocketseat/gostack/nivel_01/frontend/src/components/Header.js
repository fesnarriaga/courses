import React from 'react';

// function Header(props) {
//   return (
//     <header>
//       <h1>{props.title}</h1>
//     </header>
//   );
// }

function Header({ title, children }) {
  return (
    <header>
      <h1>{title}</h1>

      {/* <nav>
        {children}
      </nav> */}
    </header>
  );
}

export default Header;
