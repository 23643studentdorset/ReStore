import { useEffect } from "react";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useAppDispatch, useAppSelector } from "../../app/store/configureStore";
import { fetchProductsAsync, productSelectors } from "./catalogSlice";
import ProductList from "./ProductList";

export default function Catalog (){
    const products = useAppSelector(productSelectors.selectAll);
    const {productsLoaded, status} = useAppSelector (state => state.catalog);
    const dispatch = useAppDispatch();
    

  useEffect(() =>{
    agent.Catalog.list()
    if(!productsLoaded) dispatch(fetchProductsAsync());
  }, [productsLoaded])

  if(status.includes('pending')) return <LoadingComponent message='Loading products...'/>
    return(
        <>
            <ProductList products={products}></ProductList>
        </>
    )
}