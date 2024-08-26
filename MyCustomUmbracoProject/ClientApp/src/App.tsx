import reactLogo from '/react.svg'
import { HashRouter as Router, Routes, Route, Link} from 'react-router-dom';  // we're using Hash Router to override umbraco routing when  page is refreshed 
import  viteLogo  from '/vite.svg';

import { Home } from './pages/Home';
import { About } from './pages/About';
import { ContactUs } from './pages/Contact';
import { NotFound } from './pages/NotFound';
import './App.css'


export const App = () => {
  return(
    <>
    <nav>
      <h2 className="title">Vite + React + Umbraco</h2>
      <ul>
        <li>
          <a href="/">Home </a>
        </li>
        <li>
          <a href="#/about">About</a>
        </li>
        <li>
          <a href="#/contact">Contact</a>
        </li>
      </ul>
    </nav>
    <div className="App">
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://reactjs.org" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
        <a href="https://reactjs.org" target="_blank">
          <img
            src="https://user-images.githubusercontent.com/6791648/60256231-6e710c00-98d1-11e9-8120-06eecbdb858e.png"
            className="umbraco logo"
            alt="umbraco logo"
          />
        </a>
      </div>
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
          <Route path="/contact" element={<ContactUs />} />
          <Route path="*" element={<NotFound />} />
        </Routes>
      </Router>
      <div className="card"></div>
    </div>
  </>
  );
};


// function App() {
//   const [count, setCount] = useState(0)

//   return (
//     <>
//       <div>
//         <a href="https://vitejs.dev" target="_blank">
//           <img src={viteLogo} className="logo" alt="Vite logo" />
//         </a>
//         <a href="https://react.dev" target="_blank">
//           <img src={reactLogo} className="logo react" alt="React logo" />
//         </a>
//       </div>
//       <h1>Vite + React</h1>
//       <div className="card">
//         <button onClick={() => setCount((count) => count + 1)}>
//           count is {count}
//         </button>
//         <p>
//           Edit <code>src/App.tsx</code> and save to test HMR
//         </p>
//       </div>
//       <p className="read-the-docs">
//         Click on the Vite and React logos to learn more
//       </p>
//     </>
//   )
// }

export default App;

    // <>
    // <nav>
    //   <h1>Vite + React + Umbraco</h1>
    //   <ul>
    //     <li>
    //       <Link to='/'>Home</Link>
    //     </li>
    //     <li>
    //       <Link to='/about'>About</Link>
    //     </li>
    //     <li>
    //       <Link to='/contact'>Contact</Link>
    //     </li>
    //   </ul>
    // </nav>
    // <div className='App'>
    //   <div>
    //     <a href="https://vitejs.dev" target="_blank">
    //        <img src={viteLogo} className="logo" alt="Vite logo" />
    //     </a>
    //     <a href="https://react.dev" target="_blank">
    //        <img src={reactLogo} className="logo react" alt="React logo" />
    //      </a>
    //      <a href="https://reactjs.org" target="_blank">
    //         <img
    //           src="https://user-images.githubusercontent.com/6791648/60256231-6e710c00-98d1-11e9-8120-06eecbdb858e.png"
    //           className="umbraco logo"
    //           alt="umbraco logo"
    //         />
    //       </a>
    //   </div>
    //   <Router>
    //     <Routes>
    //       <Route path='/' element={<Home />} />
    //       <Route path='/about' element={<About />} />
    //       <Route path='/contact' element={<ContactUs />} />
    //       <Route path='*' element={<NotFound />} />
    //     </Routes>
    //   </Router>
    //   <div className='card'></div>
    // </div>
    // </>