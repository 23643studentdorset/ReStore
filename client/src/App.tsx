import { type } from "@testing-library/user-event/dist/type";
import { useEffect, useState } from "react";
import { Product } from "./product";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() =>{
    fetch('http://localhost:5000/api/products')
    .then(response => response.json())
    .then(data => setProducts(data))
  }, [])

  function addproduct() {
    setProducts(prevState => [...products, {
      id: prevState.length + 101,
      name: 'Product' + (prevState.length + 1), 
      price: (prevState.length * 100) + 100,
      brand: 'some brand',
      description: 'some description',
      pictureUrl: 'http//picsum.photos/200'
    }])
  }

  return (
    <div>
      <h1>Re-Store</h1>
      <ul>
        {products.map((product, index) => (
          <li key={product.id}>{product.name} - {product.price}</li>
        ))}
      </ul>
      <button onClick ={addproduct}>Add product</button>
    </div>
  );
}

export default App;
