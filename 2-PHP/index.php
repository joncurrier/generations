<!DOCTYPE html>
<html>

<?php
  $slug = end(explode('/', substr($_SERVER['REQUEST_URI'], 0, -1)));
  $jsonfile = 'recipes/' . $slug . '.json';
  $data = json_decode(file_get_contents($jsonfile), true);
?>

<head>
  <meta charset="utf-8" />
  <title>2 - <?=$data['Title'] ?></title>

  <!-- Stylesheets -->
  <link rel="stylesheet" href="/css/semantic.css">
  <link rel="stylesheet" href="/css/recipe.css">
</head>

<body>
  <div id="content">
    <?php
      include 'sidebar.php';
    ?>
    <div id="recipe-container">
      <div id="recipe">
        <div class="ui basic center aligned segment">
          <h1 class="ui header"><?php echo $data['Title'] ?></h1>
          <p><?php echo $data['Description'] ?></p>
          <p><strong>Yields:</strong> <?=$data['Yields']?></p>
          <div class="ui message">
            <i class="wait icon"></i>
            <?php
              if (array_key_exists('PrepTime', $data)) {
                echo '<span class="timer"><strong>Prep:</strong> ';
                echo $data['PrepTime'];
                echo '</span>';
              }
            ?>
            <?php
              if (array_key_exists('WaitTime', $data)) {
                echo '<span class="timer"><strong>Wait:</strong> ';
                echo $data['WaitTime'];
                echo '</span>';
              }
            ?>
            <?php
              if (array_key_exists('CookTime', $data)) {
                echo '<span class="timer"><strong>Cook:</strong> ';
                echo $data['CookTime'];
                echo '</span>';
              }
            ?>
          </div>
        </div>
        <div class="ui stackable grid">
          <div class="six wide column">
            <h2 class="ui header">Ingredients</h2>
            <div class="ui relaxed list">
              <?php
                foreach($data['Ingredients'] as $ingredient) {
                  echo '<div class="ui item">';
                  echo '<i class="square outline icon"></i>';
                  echo '<div class="content">';
                  echo $ingredient;
                  echo '</div></div>';
                }
              ?>
            </div>
          </div>
          <div class="ten wide column">
            <h2 class="ui header">Directions</h2>
            <ol class="ui relaxed list">
              <?php
                foreach($data['Directions'] as $direction) {
                  echo '<li class="item">';
                  echo $direction;
                  echo '</li>';
                }
              ?>
            </ol>
          </div>
        </div>
      </div>
    </div>
  </div>
</body>

</html>
