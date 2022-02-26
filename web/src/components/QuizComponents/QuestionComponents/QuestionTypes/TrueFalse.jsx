import React from 'react';

const TrueFalse = () => (
  <div>
    <form action="" method="post">
      <div>
        <input type="radio" id="tru" name="chicken" value="t" />
        <label htmlFor="tru">True</label>
        <input type="radio" id="fals" name="chicken" value="" />
        <label htmlFor="fals">False</label>
      </div>
    </form>
  </div>
);

export default TrueFalse;
