---
title: Lab files for "Learn To Program" training 
permalink: index.html
layout: home
---

# Develop object-oriented programming applications

The following quickstart exercises are designed to provide you with a hands-on learning experience in which you'll explore common tasks that developers do when developing object-oriented applications.

## Quickstart exercises
<hr>

{% assign labs = site.pages | where_exp:"page", "page.url contains '/Instructions/Labs'" %}

{% for activity in labs  %}

### [{{ activity.lab.title }}]({{ site.github.url }}{{ activity.url }})
{{ activity.lab.description }}
<hr>
{% endfor %}
