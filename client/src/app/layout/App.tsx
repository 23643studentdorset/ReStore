import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { useEffect, useState } from "react";
import { Route, Switch } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import AboutPage from "../../features/about/AboutPage";
import Catalog from "../../features/catalog/Catalog";
import ProductDetails from "../../features/catalog/ProductDetails";
import ContactPage from "../../features/contact/Contactpage";
import HomePage from "../../features/home/Home";
import Header from "./Header";
import 'react-toastify/dist/ReactToastify.css';
import NotFound from "../errors/NotFound";
import BasketPage from "../../features/basket/basketPage";
import { useStoreContext } from "../context/StoreContext";
import { getCookie } from "../util/util";
import agent from "../api/agent";
import LoadingComponent from "./LoadingComponent";

function App() {
  const {setBasket}= useStoreContext();
  const[loading, setLoading] = useState(true);

  useEffect (()=> {
    const buyerId = getCookie('buyerId');
    if (buyerId){
      agent.Basket.get()
        .then (basket => setBasket(basket))
        .catch(error => console.log(error))
        .finally(() => setLoading(false))
    } else {
      setLoading(false);
    }
  }, [setBasket])
  
  const[darkMode, setDarkMode] = useState(false)
  const palleteType = darkMode ? 'dark' : 'light'
  const theme = createTheme({
    palette:{
      mode: palleteType,
      background: { default: palleteType === 'light' ? '#eaeaea' : '#121212'
      
      }
    }
  })
  
function handleThemeChange(){
  setDarkMode(!darkMode);
}

  if (loading) return <LoadingComponent message="Initialising app..."/>

  return (
    <ThemeProvider theme={theme}>
      <ToastContainer position = 'bottom-right' hideProgressBar />
      <CssBaseline />
      <Header darkMode={darkMode} handleThemeChange={handleThemeChange}  />
      <Container>
        <Switch>
          <Route exact path='/' component={HomePage}/>
          <Route exact path='/catalog' component={Catalog}/>
          <Route exact path='/catalog/:id' component={ProductDetails}/>
          <Route exact path='/about' component={AboutPage}/>
          <Route exact path='/contact' component={ContactPage}/>
          <Route exact path='/basket' component={BasketPage}/>
          <Route component={NotFound}/>
        </Switch>
      </Container>
    </ThemeProvider>
  );
}

export default App;
